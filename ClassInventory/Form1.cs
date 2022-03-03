using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ClassInventory
{
    public partial class Form1 : Form
    {
        // TODO - create a List to store all inventory objects
        List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string playerName = nameInput.Text;
                string playerTeam = teamInput.Text;
                string playerPosition = positionInput.Text;
                int playerAge = Convert.ToInt32(ageInput.Text);

                Player newPlayer = new Player(playerName, playerTeam, playerPosition, playerAge);

                players.Add(newPlayer);

                confirmLabel.Text = "Player Added";
            }
            catch
            { 
                confirmLabel.Text = "Error";
            }
            Refresh();
            Thread.Sleep(1000);
            confirmLabel.Text = "";
            Refresh();

            nameInput.Text = "";
            teamInput.Text = "";
            positionInput.Text = "";
            ageInput.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // This is to be completed in Part II. You will use 
            // Lambda Expressions.
            //---------------------------

            string playerName = removeInput.Text;
            int playersRemoved = 0;
            List<Player> removedPlayers = new List<Player>();

            removedPlayers = players.FindAll(t => t.name == playerName);

            foreach(Player newPlayer in removedPlayers)
            {
                players.Remove(newPlayer);
                playersRemoved++;
            }
            removeInput.Text = "";

            if(playersRemoved > 0)
            {
                if(playersRemoved > 1)
                {
                    confirmRemoveLabel.Text = "Players Removed";
                }
                else
                {
                    confirmRemoveLabel.Text = "Player Removed";
                }
            }
            else
            {
                confirmRemoveLabel.Text = "Player Not Found";
            }
            Refresh();
            Thread.Sleep(1000);
            confirmRemoveLabel.Text = "";
            Refresh();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // This is to be completed in Part II. You will use 
            // Lambda Expressions.
            //---------------------------

            // TODO - if object entered exists in list show it
            // TODO - else show not found message

            string searchedName = nameSearchInput.Text;

            List<Player> searchedPlayers = new List<Player>();
            searchedPlayers = players.FindAll(t => t.name == searchedName);
            outputLabel.Text = "";

            foreach (Player newPlayer in searchedPlayers)
            {
                outputLabel.Text += $"{newPlayer.name}, {newPlayer.team}, {newPlayer.position}, {newPlayer.age}\n";
            }

            if(searchedPlayers.Count == 0)
            {
                outputLabel.Text = "No Players Found";
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // TODO - show all objects in list. Use a foreach loop.
            List<Player> sPlayerList = players.OrderBy(x => x.team).ThenBy(x => x.name).ToList();

            outputLabel.Text = "";

            foreach (Player newPlayer in sPlayerList)
            {
                outputLabel.Text += $"{newPlayer.name}, {newPlayer.team}, {newPlayer.position}, {newPlayer.age}\n";
            }
        }
    }
}
