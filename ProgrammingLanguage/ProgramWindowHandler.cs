using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguage
{
    /// <summary>
    /// ProgramWindowHandler class handles the programming commands that user provides
    /// </summary>
    public class ProgramWindowHandler
    {
        Parser parser;
        int maxLimit = 100;
        Boolean isMethod = false;
        String methodName;

        /// <summary>
        /// Constructor initializes the parser to work with
        /// </summary>
        /// <param name="parser"></param>
        public ProgramWindowHandler(Parser parser)
        {
            this.parser = parser;
        }

        /// <summary>
        /// Execute methods, ifs, loops and commands provided by user
        /// </summary>
        /// <param name="text">Input text of the program window</param>
        public void ExecuteBulkCommands(String[] text)
        {
            String[] splitText = new String[maxLimit];

            var variables = DefineVariables(text);
            string[] modifiedAfterLoop = LoopHandler(text, variables);
            string[] modifiedAfterMethod = MethodHandler(modifiedAfterLoop, variables);
            String[] newData = GeneratingCommands(modifiedAfterMethod, variables);
            string[] modifiedAfterIF = IfHandler(newData, variables);
            
            string[] finalData = RemoveVariables(modifiedAfterIF);

            try
            {
                if (finalData.Length != 0)
                {
                    for (int i = 0; i < finalData.Length; i++)
                    {
                        splitText[i] = finalData[i].ToString().Trim().ToLower();
                        parser.ParseCommand(splitText[i], true);
                    }
                }
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Store user defined variables and its values
        /// </summary>
        /// <param name="text">User given commands list</param>
        /// <returns>a map contains variable name as the key and number as the value</returns>
        public Dictionary<string, string> DefineVariables(String[] text)
        {
            String[] store = new String[maxLimit];
            String[] variables = new string[maxLimit];
            var map = new Dictionary<string, string>();
            var result = new Dictionary<string, string>();

            foreach (String line1 in text)
            {
                String line = line1.ToLower();
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
            result = ExpressionHandler(map);
            
            return result;

        }

        /// <summary>
        /// Assign variable values to commands if exists
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userDefinedVariables"></param>
        /// <returns>array of commands without variables</returns>
        public String[] GeneratingCommands(String[] text, Dictionary<string, string> userDefinedVariables)
        {
            
            for(int i=0; i < text.Length; i++)
            {
                String[] commandAndValue = text[i].ToLower().Split(' ');

                if(commandAndValue.Length > 0 && commandAndValue[0].Equals("circle"))
                {
                    if (userDefinedVariables.ContainsKey(commandAndValue[1]))
                    {
                        String s = userDefinedVariables[commandAndValue[1]];
                        String command = "circle " + s;
                        text[i] = command;
                    }
                }
                else if(commandAndValue.Length >0 && commandAndValue[0].Equals("rect"))
                {
                    string[] values = commandAndValue[1].Split(',');
                    string v1 = values[0];
                    string v2 = values[1];

                    if (userDefinedVariables.ContainsKey(v1))
                    {
                        v1 = userDefinedVariables[values[0]];
                    }

                    if (userDefinedVariables.ContainsKey(v2))
                    {
                        v2 = userDefinedVariables[v2];
                    }
                    string command = "rect " + v1 +"," + v2;
                    text[i] = command;
                }
            }

            return text;
        }

        /// <summary>
        /// Seperate if conditions and perform if function
        /// </summary>
        /// <param name="commandList">user defined commands list</param>
        /// <param name="userDefinedVariables">user defined variables</param>
        /// <returns>removed if functions from commands list provided by the user if there is any</returns>
        public string[] IfHandler(String[] commandList, Dictionary<string, string> userDefinedVariables)
        {
            string[] modifiedData = null;

            foreach (String line1 in commandList)
            {
                String line = line1.ToLower();
                String condition;
                if (line.Contains("if"))
                {
                    String splitter = "if";
                    string[] splitted = line.Split(new[] { splitter }, StringSplitOptions.None)
                           .Select(value => value.Trim())
                           .ToArray();
                    condition = splitted[1];

                    String[] methodBody = IfMethodBody(commandList);
                    modifiedData = commandList.Except(methodBody).ToArray();
                    IfFunction operationIF = new IfFunction(condition, methodBody, parser);
                    operationIF.Execute(userDefinedVariables);
                    break;
                }
                else
                {
                    modifiedData = commandList;
                }

            }
            return modifiedData;
        }

        /// <summary>
        /// Separate if method body from all the commands
        /// </summary>
        /// <param name="text">user defined command list</param>
        /// <returns>commands between if and endif</returns>
        public String[] IfMethodBody(String[] text)
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

        /// <summary>
        /// Separate loop function  and perform loop function
        /// </summary>
        /// <param name="commandList">user defined commands list</param>
        /// <param name="userDefinedVariables">user defined variables</param>
        /// <returns>removed loop functions from user provided commands if there is any</returns>
        public string[] LoopHandler(String[] commandList, Dictionary<string, string> userDefinedVariables)
        {
            string[] modifiedData = null;

            foreach (String line in commandList)
            {
                String condition;
                if (line.Contains("while"))
                {
                    String splitter = "while";
                    string[] splitted = line.Split(new[] { splitter }, StringSplitOptions.None)
                           .Select(value => value.Trim())
                           .ToArray();
                    condition = splitted[1];

                    String[] methodBody = LoopMethodBody(commandList);
                    modifiedData = commandList.Except(methodBody).ToArray();
                    LoopFunction loopF = new LoopFunction(condition, methodBody, parser);
                    loopF.Execute(userDefinedVariables);
                    break;
                }
                else
                {
                    modifiedData = commandList;
                }

            }
           return modifiedData;

        }

        /// <summary>
        /// Separate loop method body from all the commands
        /// </summary>
        /// <param name="text">user defined command list</param>
        /// <returns>commands between loop and endloop keywords</returns>
        public string[] LoopMethodBody(string[] text)
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

        /// <summary>
        /// Remove varibles declaration from all the commands user provided
        /// </summary>
        /// <param name="text">All the commands user provided</param>
        /// <returns>removed variable declarations from user provided command list if there is any</returns>
        public string[] RemoveVariables(string[] text)
        {
            try
            {
                if(text != null)
                {
                    string[] latest = new string[text.Length];
                    int x = 0;
                    foreach (String line in text)
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
            }
            catch(Exception ex)
            {
                return null;
            }
            return text;
        }

        /// <summary>
        /// Separate method body and execute the method function class
        /// </summary>
        /// <param name="commandList">user defined commands list</param>
        /// <param name="userDefinedVariables">user defined variables</param>
        /// <returns>removed methods partition form user provided commandlist if there is any</returns>
        public string[] MethodHandler(String[] commandList, Dictionary<string, string> userDefinedVariables)
        {
            string[] modifiedData = commandList;
            String[] methodbody = null;
            String perameters = null;
            String parameterValues = null;

            foreach (String line in commandList)
            {
                if (line.Contains("method"))
                {
                    String[] arr1 = line.Split('(');
                    string[] arr2 = arr1[0].Split(' ');
                    this.methodName = arr2[1].Trim();
                    this.isMethod = true;
                    methodbody = MethodBody(commandList);
                    modifiedData = commandList.Except(methodbody).ToArray();

                    perameters = getBracketData(line);
                }
                else if(methodName != null && line.Contains(methodName))
                {
                    if (isMethod == true)
                    {
                        parameterValues = getBracketData(line);
                        MethodFunction meth = new MethodFunction(methodbody, parser, perameters, parameterValues);
                        meth.Execute(userDefinedVariables);
                        string[] arr = new string[1];
                        arr[0] = line;
                        modifiedData = modifiedData.Except(arr).ToArray();
                    }
                }
                
            }
            return modifiedData;
        }

        /// <summary>
        /// Seperate method body from all user provided command list
        /// </summary>
        /// <param name="text">User provided command list</param>
        /// <returns>commands between method and endmethod keywords</returns>
        public string[] MethodBody(string[] text)
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

        /// <summary>
        /// Assign values to a variables that have functions
        /// </summary>
        /// <param name="map">variable and value pairs given by user</param>
        /// <returns></returns>
        public Dictionary<string, string> ExpressionHandler(Dictionary<string, string> map)
        {
            var keyCount = map.Keys.ToList();
            foreach(String key1 in keyCount)
            {
                if (map[key1].Contains("+"))
                {
                    String[] splitValues = map[key1].Split('+');
                    if (map.ContainsKey(splitValues[0]))
                    {
                        splitValues[0] = map[splitValues[0]];
                        int total = Int32.Parse(splitValues[0]) + Int32.Parse(splitValues[1]);
                        map[key1] = total.ToString();
                    }
                }
                else if (map[key1].Contains("-"))
                {
                    String[] splitValues = map[key1].Split('-');
                    if (map.ContainsKey(splitValues[0]))
                    {
                        splitValues[0] = map[splitValues[0]];
                        int total = Int32.Parse(splitValues[0]) - Int32.Parse(splitValues[1]);
                        map[key1] = total.ToString();
                    }
                }
                else if (map[key1].Contains("*"))
                {
                    String[] splitValues = map[key1].Split('*');
                    if (map.ContainsKey(splitValues[0]))
                    {
                        splitValues[0] = map[splitValues[0]];
                        int total = Int32.Parse(splitValues[0]) * Int32.Parse(splitValues[1]);
                        map[key1] = total.ToString();
                    }
                }
            }
            return map;
        }


        public string getBracketData(String line)
        {
            String result = null;
            string[] arr1 = line.Split('(');
            string[] arr2 = arr1[1].Split(')');
            result = arr2[0];

            return result;
        }

    }
}
