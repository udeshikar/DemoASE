using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguage
{
    class ProgramWindowHandler
    {
        Canvas canvas;
        Parser parser;
        int maxLimit = 100;
        int count = 0;
        Boolean isMethod = false;
        String methodName;
        public ProgramWindowHandler(Parser parser)
        {
            //this.canvas = canvas;
            this.parser = parser;
        }

        public void SeperateLines(String[] text)
        {
            //string[] text = richText.Lines;
            String[] splitText = new String[maxLimit];

            var variables = defineVariables(text);
            string[] modifiedAfterLoop = loopHandler(text, variables);
            string[] modifiedAfterMethod = methodHandler(modifiedAfterLoop, variables);
            String[] newData = generatingCommands(modifiedAfterMethod, variables);
            string[] modifiedAfterIF = ifHandler(newData, variables);
            
            string[] finalData = removeVariables(modifiedAfterIF);

            if(finalData.Length != 0)
            {
                for (int i = 0; i < finalData.Length; i++)
                {
                    splitText[i] = finalData[i].ToString().Trim().ToLower();
                    parser.ParseCommand(splitText[i], true);
                }
            }
            
            
        }

        public Dictionary<string, string> defineVariables(String[] text)
        {
            String[] store = new String[maxLimit];
            String[] variables = new string[maxLimit];
            var map = new Dictionary<string, string>();



            foreach (String line in text)
            {
                if (line.Contains("=") && !line.Contains("if"))
                {
                    variables = line.Split('=');
                    variables[0] = variables[0].Trim();
                    variables[1] = variables[1].Trim();

                    if (map.ContainsKey(variables[0]))
                    {
                        map.Add(variables[1], variables[1]);
                    }
                    else
                    {
                        map.Add(variables[0], variables[1]);
                    }
                }
            }
            return map;

        }

        public String[] generatingCommands(String[] text, Dictionary<string, string> data)
        {
            
            for(int i=0; i < text.Length; i++)
            {
                String[] commandAndValue = text[i].ToLower().Split(' ');

                if(commandAndValue.Length > 0 && commandAndValue[0].Equals("circle"))
                {
                    if (data.ContainsKey(commandAndValue[1]))
                    {
                        String s = data[commandAndValue[1]];
                        String command = "circle " + s;
                        text[i] = command;
                    }
                }
                else if(commandAndValue.Length >0 && commandAndValue[0].Equals("rect"))
                {
                    string[] values = commandAndValue[1].Split(',');
                    string v1 = values[0];
                    string v2 = values[1];

                    if (data.ContainsKey(v1))
                    {
                        v1 = data[values[0]];
                    }

                    if (data.ContainsKey(v2))
                    {
                        v2 = data[v2];
                    }
                    string command = "rect " + v1 +"," + v2;
                    text[i] = command;
                }
            }

            return text;
        }

        public string[] ifHandler(String[] text, Dictionary<string, string> data)
        {
            string[] modifiedData = null;

            foreach (String line in text)
            {
                String condition;
                if (line.Contains("if"))
                {
                    String splitter = "if";
                    string[] splitted = line.Split(new[] { splitter }, StringSplitOptions.None)
                           .Select(value => value.Trim())
                           .ToArray();
                    condition = splitted[1];

                    String[] methodBody = ifMethodBody(text);
                    modifiedData = text.Except(methodBody).ToArray();
                    IfFunction operationIF = new IfFunction(condition, methodBody, parser);
                    operationIF.Execute(data);
                    break;
                }
                else
                {
                    modifiedData = text;
                }

            }
            return modifiedData;
        }

        public String[] ifMethodBody(String[] text)
        {
            int start = -1;
            int end = -1;
            String[] body = new string[text.Length];
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("if"))
                {
                    start = i;
                }

                if (text[i].Contains("end"))
                {
                    end = i;
                }
            }

            if (start >= 0 && end >= 0)
            {
                body = new string[end - start + 1];
                for (int j = 0; j < body.Length; j++)
                {
                    body[j] = text[start + j];
                }
            }
            return body;
        }

        public string[] loopHandler(String[] text, Dictionary<string, string> data)
        {
            string[] modifiedData = null;

            foreach (String line in text)
            {
                String condition;
                if (line.Contains("while"))
                {
                    String splitter = "while";
                    string[] splitted = line.Split(new[] { splitter }, StringSplitOptions.None)
                           .Select(value => value.Trim())
                           .ToArray();
                    condition = splitted[1];

                    String[] methodBody = loopMethodBody(text);
                    modifiedData = text.Except(methodBody).ToArray();
                    LoopFunction loopF = new LoopFunction(condition, methodBody, parser);
                    loopF.Execute(data);
                    break;
                }
                else
                {
                    modifiedData = text;
                }

            }
           return modifiedData;

        }

        public string[] loopMethodBody(string[] text)
        {
            int start = -1;
            int end = -1;
            String[] body = new string[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("while"))
                {
                    start = i;
                }

                if (text[i].Contains("endloop"))
                {
                    end = i;
                }
            }

            if (start >= 0 && end >= 0)
            {
                body = new string[end - start + 1];
                for (int j = 0; j < body.Length; j++)
                {
                    body[j] = text[start + j];
                }
            }
            return body;
        }

        public string[] removeVariables(string[] text)
        {
            string[] latest = new string[text.Length];
            int x = 0;
            foreach(String line in text)
            {
                if (line.Contains("="))
                {
                    latest[x] = line;
                    x++;
                }
            }

            string[] result = text.Except(latest).ToArray();
            return result;
        }

        public string[] methodHandler(String[] text, Dictionary<string, string> data)
        {
            string[] modifiedData = text;
            String[] methodbody = null;

            foreach (String line in text)
            {
                if (line.Contains("method"))
                {
                    String[] arr1 = line.Split('(');
                    string[] arr2 = arr1[0].Split(' ');
                    this.methodName = arr2[1].Trim();
                    this.isMethod = true;
                    methodbody = methodBody(text);
                    modifiedData = text.Except(methodbody).ToArray();
                }
                else if(methodName != null && line.Contains(methodName))
                {
                    if (isMethod == true)
                    {
                        MethodFunction meth = new MethodFunction(methodbody, parser);
                        meth.Execute(data);
                        string[] arr = new string[1];
                        arr[0] = line;
                        modifiedData = modifiedData.Except(arr).ToArray();
                    }
                }
                
            }
            return modifiedData;
        }

        public string[] methodBody(string[] text)
        {
            int start = -1;
            int end = -1;
            String[] body = new string[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("method"))
                {
                    start = i;
                }

                if (text[i].Contains("end"))
                {
                    end = i;
                }
            }

            if (start >= 0 && end >= 0)
            {
                body = new string[end - start + 1];
                for (int j = 0; j < body.Length; j++)
                {
                    body[j] = text[start + j];
                }
            }
            return body;
        }

    }
}
