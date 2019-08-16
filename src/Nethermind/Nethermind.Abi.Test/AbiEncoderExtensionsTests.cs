using NSubstitute;
using NUnit.Framework;

namespace Nethermind.Abi.Test
{
    public class AbiEncoderExtensionsTests
    {
        [Test]
        public void Encode_should_be_called()
        {
            var abi = Substitute.For<IAbiEncoder>();
            var parameters = new object[] {"p1"};
            var abiSignature = new AbiSignature("test", AbiType.String);
            var abiEncodingStyle = AbiEncodingStyle.Packed;
            
            abi.Encode(new AbiEncodingInfo(abiEncodingStyle, abiSignature), parameters);
            abi.Received().Encode(abiEncodingStyle, abiSignature, parameters);
        }
        
        [Test]
        public void Dencode_should_be_called()
        {
            var abi = Substitute.For<IAbiEncoder>();
            var data = new byte[] {100, 200};
            var abiSignature = new AbiSignature("test", AbiType.String);
            var abiEncodingStyle = AbiEncodingStyle.Packed;
            
            abi.Decode(new AbiEncodingInfo(abiEncodingStyle, abiSignature), data);
            abi.Received().Decode(abiEncodingStyle, abiSignature, data);
        }
    }
}