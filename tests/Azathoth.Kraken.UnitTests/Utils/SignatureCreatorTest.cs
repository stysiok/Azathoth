using Azathoth.Kraken.Models.Requests;
using Azathoth.Kraken.Utils;
using Xunit;

namespace Azathoth.Kraken.UnitTests.Utils
{
    public class SignatureCreatorTests
    {
        [Fact]
        public void SignatureCreator_creates_valid_signature()
        {
            const string EXPECTED_SIGNATURE = "4/dpxb3iT4tp/ZCVEwSnEsLxx0bqyhLpdfOpc6fn7OR8+UClSV5n9E6aSS8MPtnRfp32bAb0nmbRn6H8ndwLUQ==";
            var signatureCreator = new SignatureCreator();
            
            var signature = signatureCreator.CreateSignature("/0/private/AddOrder", 
                "kQH5HW/8p1uGOVjbgWA7FunAmGO8lsSUXNsu3eow76sz84Q18fWxnyRzBHCd3pd5nE9qa99HAZtuZuj6F1huXg==",
                new FakePrivateRequest());

            Assert.Equal(EXPECTED_SIGNATURE, signature);
        }
    }

    record FakePrivateRequest : PrivateKrakenRequestBase
    {
        public override long Nonce => 1616492376594;
        public string OrderType => "limit";
        public string Pair => "XBTUSD";
        public int Price => 37500;
        public string Type => "buy";
        public double Volume => 1.25d;
    }
}