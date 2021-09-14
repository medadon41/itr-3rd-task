using ConsoleTables;

namespace Task3
{
    public class Table
    {
        private readonly Winner _winner = new();

        private void FillingTableHead(string[] args, string[] tableHead)
        {
            tableHead[0] = "PC\\Player";
            for (int i = 0; i < args.Length; i++) tableHead[i + 1] = args[i];
        }

        private void FillingArrayForRows(string[] args, object[][] itemsForTable, int i)
        {
            for (int j = 0; j < args.Length; j++)
                itemsForTable[i][j + 1] = _winner.CheckingResults(args, i, j);
        }

        private void AddRows(string[] args, object[][] itemsForTable, ConsoleTable table)
        {
            for (int i = 0; i < args.Length; i++)
            {
                itemsForTable[i] = new object[args.Length + 1];
                itemsForTable[i][0] = args[i];
                FillingArrayForRows(args, itemsForTable, i);
                table.AddRow(itemsForTable[i]);
            }
        }

        public void CreateTable(string[] args)
        {
            object[][] itemsForTable = new object[args.Length + 1][];
            string[] tableHead = new string[args.Length + 1];
            FillingTableHead(args, tableHead);
            var table = new ConsoleTable(tableHead);
            AddRows(args, itemsForTable, table);
            table.Write(Format.Alternative);
        }
    }
}