using Microsoft.IdentityModel.Tokens;
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

var innerPayload = Base64UrlEncoder.Decode(innerPayloadEncoded);

var bundleIdRegex = new Regex(@"""bundleId"": ?""(.+?)""");
innerPayload = bundleIdRegex.Replace(innerPayload, "\"bundleId\": \"com.example.app\"");

var signedTransactionInfoRegex = new Regex(@"""signedTransactionInfo"": ?""(.+?)""");
var signedTransactionInfo = signedTransactionInfoRegex.Match(innerPayload).Value;
var signedTransactionInfoSplit = signedTransactionInfo.Split('.');
var signedTranscationInfoPayloadEncoded = signedTransactionInfoSplit[1];
var signedTransactionInfoPayload = Base64UrlEncoder.Decode(signedTranscationInfoPayloadEncoded);
signedTransactionInfoPayload = bundleIdRegex.Replace(signedTransactionInfoPayload, "\"bundleId\": \"com.example.app\"");
signedTranscationInfoPayloadEncoded = Base64UrlEncoder.Encode(signedTransactionInfoPayload);
signedTransactionInfo =
    $"{signedTransactionInfoSplit[0]}.{signedTranscationInfoPayloadEncoded}.{signedTransactionInfoSplit[2]}";
innerPayload = signedTransactionInfoRegex.Replace(innerPayload, signedTransactionInfo);
innerPayloadEncoded = Base64UrlEncoder.Encode(innerPayload);
var payloadStr = $"{payloadSplit[0]}.{innerPayloadEncoded}.{payloadSplit[2]}";

await File.WriteAllTextAsync(filePath + ".scambled", payloadStr);
Console.WriteLine($"Wrote to {filePath}.scambled");