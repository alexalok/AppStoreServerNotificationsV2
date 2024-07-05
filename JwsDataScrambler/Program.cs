using System.Text;
using System.Text.RegularExpressions;

if (args.Length < 1)
{
    Console.WriteLine("Drag payload on this EXE file.");
    return;
}

var filePath = args[0];
if (!File.Exists(filePath))
{
    Console.WriteLine("Specified file does not exist.");
    return;
}

var contents = await File.ReadAllTextAsync(filePath);

var payloadSplit = contents.Split('.');
var innerPayloadEncoded = payloadSplit[1];

var innerPayload = Encoding.UTF8.GetString(Convert.FromBase64String(innerPayloadEncoded + "=="));

var bundleIdRegex = new Regex(@"""bundleId"": ?""(.+?)""");
innerPayload = bundleIdRegex.Replace(innerPayload, "\"bundleId\": \"com.example.app\"");

var signedTransactionInfoRegex = new Regex(@"""signedTransactionInfo"": ?""(.+?)""");
var signedTransactionInfo = signedTransactionInfoRegex.Match(innerPayload).Value;
var signedTransactionInfoSplit = signedTransactionInfo.Split('.');
var signedTranscationInfoPayloadEncoded = signedTransactionInfoSplit[1];
var signedTransactionInfoPayload = Encoding.UTF8.GetString(
    Convert.FromBase64String(signedTranscationInfoPayloadEncoded + "=="));
signedTransactionInfoPayload = bundleIdRegex.Replace(signedTransactionInfoPayload, "\"bundleId\": \"com.example.app\"");
signedTranscationInfoPayloadEncoded = Convert.ToBase64String(
    Encoding.UTF8.GetBytes(signedTransactionInfoPayload)).TrimEnd('=');
signedTransactionInfo =
    $"{signedTransactionInfoSplit[0]}.{signedTranscationInfoPayloadEncoded}.{signedTransactionInfoSplit[2]}";
innerPayload = signedTransactionInfoRegex.Replace(innerPayload, signedTransactionInfo);
innerPayloadEncoded = Convert.ToBase64String(
    Encoding.UTF8.GetBytes(innerPayload)).TrimEnd('=');
var payloadStr = $"{payloadSplit[0]}.{innerPayloadEncoded}.{payloadSplit[2]}";

await File.WriteAllTextAsync(filePath + ".scambled", payloadStr);
Console.WriteLine($"Wrote to {filePath}.scambled");