#nullable enable

using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Assert = NUnit.Framework.Assert;

namespace Fiks.Plan.V2.Samples.Tests
{
    public class TestCasesTests : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly JsonValidator _jsonValidator;
        public TestCasesTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _jsonValidator = JsonValidator.Init().WithFiksPlan();

        }
        
        [Fact]
        public void FiksSaksfaser_TestCases_Are_Valid()
        {
            List<string> validationErrors = new List<string>();
            
            var samplesDirectories = Directory.GetDirectories("Samples");
            foreach (var sampleDir in samplesDirectories)
            {
                
                var json = File.ReadAllText($"{sampleDir}/payload.json");

                _testOutputHelper.WriteLine($"Validating testcase {sampleDir}");

                _jsonValidator.Validate(json, validationErrors, messageType);
                foreach (var validationError in validationErrors)
                {
                    _testOutputHelper.WriteLine(validationError);
                }
                Assert.IsEmpty(validationErrors);
            }
        }

        public void Dispose()
        {
            _jsonValidator.Dispose();
        }
    }
}