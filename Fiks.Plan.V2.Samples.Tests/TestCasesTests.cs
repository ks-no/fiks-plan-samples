#nullable enable

using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Assert = NUnit.Framework.Assert;

namespace Fiks.Plan.V2.Samples.Tests
{
    public class TestCasesTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public TestCasesTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

        }
        
        [Fact]
        public void FiksPlanSamples_Folders_Has_Payload()
        {
            List<string> validationErrors = new List<string>();
            
            var samplesDirectories = Directory.GetDirectories("Samples/Fiks.Plan.V2");
            foreach (var sampleDir in samplesDirectories)
            {
                
                var json = File.ReadAllText($"{sampleDir}/payload.json");
                _testOutputHelper.WriteLine($"Validating testcase {sampleDir}");
                Assert.IsNotEmpty(json);
            }
        }
    }
}