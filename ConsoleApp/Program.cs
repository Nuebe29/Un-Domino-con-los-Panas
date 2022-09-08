using Engine;

List<Player<int>> list =  new List<Player<int>>();
list.Add(new Player<int>(Estrategias<int>.Botagordas, "yo"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom, "tu"));
list.Add(new Player<int>(Estrategias<int>.Botagordas, "el"));
list.Add(new Player<int>(Estrategias<int>.NoPasarse, "ella"));

var a = new Partida<int>();
a.RecibeParametros(new EndconditionPorPases3(5),new GanadorPorJugadas(), new MatcherClasico(), new Dealer<int>(), new Generadorclasico(), list, 9, new TurnerClasico(), 7);
a.RunTurn();
a.RunTurn();
a.RunTurn();
a.RunTurn();

System.Console.WriteLine(a.Players[0].name);


