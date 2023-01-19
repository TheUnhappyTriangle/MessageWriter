using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepetitiveMessageWriter
{
    internal class MessageWriter
    {
        public string SingleStringReplace (List<string> baseMessage, string target, string separator, string newString)
        {
            var msgParts = baseMessage;
            if (msgParts.Contains(target))
            {
                for (int i = 0; i < msgParts.Count; i++)
                {
                    if (msgParts[i].Equals(target)) msgParts[i] = newString;
                }
            }

            return string.Join(separator, msgParts);
        }
    }
}


