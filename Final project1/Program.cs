using System;
using System.Collections.Generic;

// Player class
public class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int PlayerAge { get; set; }
}

// ITeam interface
public interface ITeam
{
    void Add(Player player);
    void Remove(int playerId);
    Player GetPlayerById(int playerId);
    Player GetPlayerByName(string playerName);
    List<Player> GetAllPlayers();
}

// OneDayTeam class implementing ITeam interface
public class OneDayTeam : ITeam
{
    public static List<Player> oneDayTeam = new List<Player>();

    public OneDayTeam()
    {
        // Set the capacity property to 11
        oneDayTeam.Capacity = 11;
    }

    public void Add(Player player)
    {
        if (oneDayTeam.Count < 11)
        {
            oneDayTeam.Add(player);
            Console.WriteLine("Player added successfully");
        }
        else
        {
            Console.WriteLine("Cannot add more than 11 players to the team");
        }
    }

    public void Remove(int playerId)
    {
        Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
        if (playerToRemove != null)
        {
            oneDayTeam.Remove(playerToRemove);
            Console.WriteLine("Player removed successfully");
        }
        else
        {
            Console.WriteLine("Player not found");
        }
    }

    public Player GetPlayerById(int playerId)
    {
        return oneDayTeam.Find(p => p.PlayerId == playerId);
    }

    public Player GetPlayerByName(string playerName)
    {
        return oneDayTeam.Find(p => p.PlayerName == playerName);
    }

    public List<Player> GetAllPlayers()
    {
        return oneDayTeam;
    }
}

// Program class
class Program
{
    static void Main()
    {
        OneDayTeam oneDayTeam = new OneDayTeam();

        string choice;
        do
        {
            Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3. Get Player By Id 4. Get Player by Name 5. Get All Players:");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter Player Id:");
                    int playerId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Player Name:");
                    string playerName = Console.ReadLine();

                    Console.WriteLine("Enter Player Age:");
                    int playerAge = int.Parse(Console.ReadLine());

                    Player newPlayer = new Player { PlayerId = playerId, PlayerName = playerName, PlayerAge = playerAge };
                    oneDayTeam.Add(newPlayer);
                    break;

                case 2:
                    Console.WriteLine("Enter Player Id to Remove:");
                    int idToRemove = int.Parse(Console.ReadLine());
                    oneDayTeam.Remove(idToRemove);
                    break;

                case 3:
                    Console.WriteLine("Enter Player Id:");
                    int idToGetById = int.Parse(Console.ReadLine());
                    Player playerById = oneDayTeam.GetPlayerById(idToGetById);
                    if (playerById != null)
                        Console.WriteLine($"{playerById.PlayerId} {playerById.PlayerName} {playerById.PlayerAge}");
                    else
                        Console.WriteLine("Player not found");
                    break;

                case 4:
                    Console.WriteLine("Enter Player Name:");
                    string nameToGetByName = Console.ReadLine();
                    Player playerByName = oneDayTeam.GetPlayerByName(nameToGetByName);
                    if (playerByName != null)
                        Console.WriteLine($"{playerByName.PlayerId} {playerByName.PlayerName} {playerByName.PlayerAge}");
                    else
                        Console.WriteLine("Player not found");
                    break;

                case 5:
                    List<Player> allPlayers = oneDayTeam.GetAllPlayers();
                    foreach (var player in allPlayers)
                    {
                        Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.PlayerAge}");
                    }
                    break;





                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.WriteLine("Do you want to continue (yes/no)?:");
            choice = Console.ReadLine();
        } while (choice.ToLower() == "yes");
    }
}