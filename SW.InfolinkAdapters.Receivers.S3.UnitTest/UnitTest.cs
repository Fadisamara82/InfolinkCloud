using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.PrimitiveTypes;
using SW.Serverless.Sdk;

namespace SW.InfolinkAdapters.Receivers.S3.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async Task TestMethod1() 
        {
                var handler = new Handler(
                        
                    );
                Runner.MockRun(handler, new ServerlessOptions(), 
                    new Dictionary<string, string>
                    {
                        {CommonProperties.SecretAccessKey, "TBU"},
                        {CommonProperties.AccessKeyId, "TBU"},
                        {CommonProperties.TargetPath, "TBU"},
                        {CommonProperties.Url, "TBU"},
                    });
                await handler.Initialize();
                var names = await handler.ListFiles();
                var list = names.ToList();
                foreach (var name in list)
                {
                    await handler.GetFile(name);
                }
                
        }
    }
}