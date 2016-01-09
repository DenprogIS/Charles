using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace CharlesNewVersion
{
    class Mind
    {
        private string commandInSoundIntroduce, keys = "", currentPathWindowExplorer, currentContentWindowExplorer,
        lastPathWindowExplorer, lastContentWindowExplorer;
        private ArrayList AllTools = new ArrayList();
        public bool selfLearningAllowed = false;
        
        //BEGIN appendix function
        private void writeInBase(Tool toolWrite)
        {
            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\toolsBase.txt", true);
            writer.WriteLine(toolWrite.ToStr(toolWrite));
            writer.Close();
        }

        private ArrayList readFromBase()
        {
            string toolsInString;
            ArrayList tools = new ArrayList();
            StreamReader reader = new StreamReader(Application.StartupPath + @"\toolsBase.txt");
            toolsInString = reader.ReadToEnd();
            toolsInString = toolsInString.Replace("\n", "");
            toolsInString = toolsInString.Replace("\r", "");
            reader.Close();
            string toolString;
            while (toolsInString.IndexOf(" ") != -1) //while tools are
            {
                toolString = toolsInString.Substring(0, toolsInString.IndexOf("endOfTool")); //getting of tool
                toolsInString = toolsInString.Remove(0, toolsInString.IndexOf("endOfTool") + ("endOfTool").Length); //remove tool from tools
                Tool tool = new Tool(toolString);
                tools.Add(tool);
            }
            return tools;
        }

        private int getNumberCommand(int size)
        {
            Random rand = new Random();
            return rand.Next(0, size);
        }

        private void additionalTools(Tool first, Tool second)
        {
            Tool newTool = new Tool(second.getRecognedSoundCommand(), first.getCommandsInKeys() 
                + second.getCommandsInKeys(), first.getPath(true), first.getContent(true), second.getContent(false), second.getPath(false));
        }
        //END appendix function

        public Mind()
        {
            ArrayList toolsBase = readFromBase();
            foreach (Tool tool in toolsBase)
            {
                AllTools.Add(tool);
            }
        }
        private string think(Tool needToMadeTool)
        {
            foreach (Tool tool in AllTools)
            {
                if ((tool.getContent(false) == needToMadeTool.getContent(true))
                && (tool.getPath(true) == currentPathWindowExplorer) && (tool.getContent(true) == currentContentWindowExplorer))
                {
                    return (tool.getCommandsInKeys() + needToMadeTool.getCommandsInKeys());
                }
            }
            return null;
        }

        public string findSolution()
        {
            Tool needToMadeTool = null;
            foreach (Tool tool in AllTools)
            {
                if ((tool.getRecognedSoundCommand() == commandInSoundIntroduce)
                && (tool.getPath(true) == currentPathWindowExplorer) && (tool.getContent(true) == currentContentWindowExplorer))
                {
                    return tool.getCommandsInKeys();
                }
                if (tool.getRecognedSoundCommand() == commandInSoundIntroduce)
                {
                    needToMadeTool = tool;
                }
            }
            if (needToMadeTool != null)
                return think(needToMadeTool);
            return null;
        }

        public void setCurrentPathContent(string path, string content)
        {
            currentPathWindowExplorer = path;
            currentContentWindowExplorer = content;
        }

        public void setEndCurrentPathContent(string path, string content)
        {
            lastPathWindowExplorer = path;
            lastContentWindowExplorer = content;
        }

        public void setCommand(string command)
        {
            commandInSoundIntroduce = command;
        }

        public void addKey(string key)
        {
            keys += key;
        }

        public void addTool()
        {
            Tool newTool = new Tool(commandInSoundIntroduce, keys, currentPathWindowExplorer, currentContentWindowExplorer, lastContentWindowExplorer, lastPathWindowExplorer);
            AllTools.Add(newTool);
            writeInBase(newTool);
            commandInSoundIntroduce = null;
            keys = null;
            currentContentWindowExplorer = null;
            currentPathWindowExplorer = null;
            lastContentWindowExplorer = null;
            lastPathWindowExplorer = null;
        }

        public void getUIPresentation(ref string name,ref string beginPath, ref string endPath, ref string beginContent, ref string endContent)
        {
            name = "tool" + AllTools.Count;
            beginPath = (AllTools[AllTools.Count-1] as Tool).getPath(true);
            endPath = (AllTools[AllTools.Count-1] as Tool).getPath(false);
            beginContent = (AllTools[AllTools.Count-1] as Tool).getContent(true);
            endContent = (AllTools[AllTools.Count-1] as Tool).getContent(false);
        }

        /*public void startSelfLearning()
        {
            int firstNumberTool=0, secondNumberTool=0;
            while (selfLearningAllowed)
            {
                firstNumberTool = getNumberCommand(AllTools.Count);
                secondNumberTool = getNumberCommand(AllTools.Count);
                while (secondNumberTool==firstNumberTool)
                {
                    secondNumberTool = getNumberCommand(AllTools.Count);
                }
                additionalTools((AllTools[firstNumberTool] as Tool), (AllTools[secondNumberTool] as Tool));
            }
        }*/
    }
}
