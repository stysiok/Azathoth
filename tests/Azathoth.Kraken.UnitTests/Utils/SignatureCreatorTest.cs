using System.Net.Http;
using System.Threading.Tasks;
using Azathoth.Kraken.Client;
using Azathoth.Kraken.Models.Requests;
using Azathoth.Kraken.Utils;
using Moq;
using Xunit;

namespace Azathoth.Kraken.UnitTests.Utils
{
    public class SignatureCreatorTests
    {
        [Fact]
        public void SignatureCreator_ValidSignature()
        {
            const string EXPECTED_SIGNATURE = "4/dpxb3iT4tp/ZCVEwSnEsLxx0bqyhLpdfOpc6fn7OR8+UClSV5n9E6aSS8MPtnRfp32bAb0nmbRn6H8ndwLUQ==";
            var signatureCreator = new SignatureCreator();
            
            var signature = signatureCreator.CreateSignature("/0/private/AddOrder", 
                "nonce=1616492376594&ordertype=limit&pair=XBTUSD&price=37500&type=buy&volume=1.25", 
                1616492376594, 
                "kQH5HW/8p1uGOVjbgWA7FunAmGO8lsSUXNsu3eow76sz84Q18fWxnyRzBHCd3pd5nE9qa99HAZtuZuj6F1huXg==");

            Assert.Equal(EXPECTED_SIGNATURE, signature);
        }
    }
}