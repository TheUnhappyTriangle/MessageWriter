namespace RepetitiveMessageWriter
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // For specific MC problem
            string toReplace = "[NAMEHERE]";
            
            List<string> fishPokemon = new List<string>() { 
                "Seel", "Dewgong", "Horsea", "Seadra", "Goldeen", "Seaking", "Magikarp", "Lapras",
                "Lanturn", "Qwilfish", "Remoraid", "Kingdra",
                "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Barboach", "Whiscash", "Feebas", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Kyogre",
                "Finneon", "Lumineon", "Mantyke",
                "Basculin", "Tirtouga", "Alomomola", 
                "Binacle", "Skrelp",
                "Popplio", "Brionne", "Primarina", "Wishiwashi", "Bruxish", "Pyukumuku",
                "Arrokuda", "Barraskewda", "Pincurchin", "Basculegion", "Overqwil"};

            MessageWriter commandWriter = new MessageWriter(); ;
            List<string> allCommands = new List<string>();
            foreach (var pokemon in fishPokemon)
            {
                List<string> command_give = new List<string>() {
                "execute if entity @e[type=pixelmon:pixelmon,name=\"", toReplace,
                "\",nbt={OnGround:1b}] run effect give @e[type=pixelmon:pixelmon,name=\"", toReplace,
                "\",nbt={OnGround:1b}] minecraft:slowness 1000000 20 true"};
                List<string> command_clear = new List<string>() {
                "execute if entity @e[type=pixelmon:pixelmon,name=\"", toReplace,
                "\",nbt={OnGround:0b}] run effect clear @e[type=pixelmon:pixelmon,name=\"", toReplace,
                "\",nbt={OnGround:0b}] minecraft:slowness"};
                // effect give
                allCommands.Add(commandWriter.SingleStringReplace(command_give, toReplace, string.Empty, pokemon));
                // effect take
                allCommands.Add(commandWriter.SingleStringReplace(command_clear, toReplace, string.Empty, pokemon));
            }

            string fullList = string.Join("\n", allCommands);
            //Console.WriteLine(fullList);
            File.WriteAllText("MC_Commands.txt", fullList);
        }
    }
}