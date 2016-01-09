namespace CharlesNewVersion
{
    class Tool
    {
        private string recognedSoundCommand;
        private string commandsInKeys;
        private string beginPath;
        private string beginContent;
        private string endPath;
        private string endContent;

        public Tool(string pRecognedSoundCommand, string pCommandsInKeys, string pBeginPath, string pBeginContent, string pEndContent, string pEndPath)
        {
            recognedSoundCommand = pRecognedSoundCommand;
            commandsInKeys = pCommandsInKeys;
            beginPath = pBeginPath;
            beginContent = pBeginContent;
            endPath = pEndPath;
            endContent = pEndContent;
        }

        public Tool(string toolInString)
        {
            string arg;
            int numberOfArgument = 0;
            while (toolInString.IndexOf(">") != -1) //while arguments are
            {
                arg = toolInString.Substring(0, toolInString.IndexOf(">")); //getting of argument
                toolInString = toolInString.Remove(0, toolInString.IndexOf(">") + 1); //remove argument from arguments
                switch (numberOfArgument)
                {
                    case 0:
                    {
                        recognedSoundCommand = arg;
                        break;
                    }
                    case 1:
                    {
                        commandsInKeys = arg;
                        break;
                    }
                    case 2:
                    {
                        beginPath = arg;
                        break;
                    }
                    case 3:
                    {
                        beginContent = arg;
                        break;
                    }
                    case 4:
                    {
                        endContent = arg;
                        break;
                    }
                    case 5:
                    {
                        endPath = arg;
                        break;
                    }
                }
                numberOfArgument++;
            }
        }

        public string getRecognedSoundCommand()
        {
            return recognedSoundCommand;
        }
        public string getCommandsInKeys()
        {
            return commandsInKeys;
        }

        public string getPath(bool begin)
        {
            if (begin)
                return beginPath;
            else
            {
                return endPath;
            }
        }

        public string getContent(bool begin)
        {
            if (begin)
                return beginContent;
            else
            {
                return endContent;
            }
        }

        public string ToStr(Tool tool)
        {
            string stringIntroduce = "";
            stringIntroduce += recognedSoundCommand + ">" + commandsInKeys + ">" + beginPath + ">" + beginContent + ">" + endContent + ">" + endPath + ">" + "endOfTool";
            return stringIntroduce;
        }
    }
}
