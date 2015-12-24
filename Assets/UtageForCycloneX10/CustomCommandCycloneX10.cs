using UnityEngine;
using System;

namespace Utage
{
    public class CustomCommandCycloneX10 : AdvCustomCommandManager
    {
        public override void OnBootInit()
        {
            Utage.AdvCommandParser.OnCreateCustomCommnadFromID += CreateCustomCommand;
        }

        public override void OnClear()
        {
            CycloneX10 cycloneX10 = GetComponent<CycloneX10>();
            if (cycloneX10)
            {
                cycloneX10.pattern = 0;
                cycloneX10.level = 0;
            }
        }

        public void CreateCustomCommand(string id, StringGridRow row, AdvSettingDataManager dataManager, ref AdvCommand command)
        {
            switch (id)
            {
                case "CycloneX10":
                    command = new AdvCommandCycloneX10(row);
                    break;
            }
        }
    }

    public class AdvCommandCycloneX10 : AdvCommand
    {
        public AdvCommandCycloneX10(StringGridRow row)
            : base(row)
        {
            this.pattern = ParseCell<int>(AdvColumnName.Arg1);
            this.level = ParseCell<int>(AdvColumnName.Arg2);
        }

        public override void DoCommand(AdvEngine engine)
        {
            CycloneX10 cycloneX10 = engine.GetComponent<CycloneX10>();
            if (cycloneX10 == null)
            {
                cycloneX10 = engine.gameObject.AddComponent<CycloneX10>();
            }

            cycloneX10.pattern = pattern;
            cycloneX10.level = level;
        }

        int pattern;
        int level;
    }
}
