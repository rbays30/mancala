using System;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

// Create a linked list
int[] marbleArray = [1,2,4,3,2,3,4,5,3,2,1,2,4,6];
Board playBoard = new Board(marbleArray);
int count = 0;
foreach (Pocket pocket in playBoard.listPockets)
{
    try
    {
        Console.WriteLine("Pocket " + count.ToString() + " " + pocket.marbles.ToString() + " " + pocket.next.marbles.ToString() + " " + pocket.across.marbles.ToString() + " " + pocket.isMancala.ToString() + " " + pocket.isMine.ToString());
    }
    catch (System.Exception)
    {
        Console.WriteLine("Pocket " + count.ToString() + " " + pocket.marbles.ToString() + " " + pocket.next.marbles.ToString() + " none" + " " + pocket.isMancala.ToString()+ " " + pocket.isMine.ToString());

    }
    
    count += 1;
}

public class Pocket
{
    public int marbles {get; set;}
    public Pocket? next {get; set;}
    public Pocket? across {get; set;}
    public bool isMancala {get; set;}

    public bool isMine {get; set;}

    public Pocket(int Marbles, bool IsMancala, bool IsMine)
    {
        marbles = Marbles;
        isMancala = IsMancala;
        isMine = IsMine;
    }

    
}

public class Board
{
    public List<Pocket> listPockets;
    public int[] marbleArray;

    public Board(int[] marbles)
    {
        listPockets = new List<Pocket>();
        marbleArray = marbles;
        createBoard();
        
        bool checkWin()
        {
            for(int i = 0; i < 6; i++)
            {
                if(listPockets[i].marbles != 0)
                {
                    return false;
                }
            }
            return true;
        }


        //To do
        bool checkPathway(int index)
        {
            //Drop one marble in each next pocket until it runs out
            Pocket endingPocket;


            //Check for win
            if(checkWin())
            {
                return true;
            }

            //Check for extra turn

            //Check for win

            return false;

        }

    }
    void createBoard()
    {
        bool isMancala;
        bool isMine;

        for(int i = 0; i < 14; i++ )
        {
            if( i < 7)
            {
                isMine=true;
                
            }
            else
            {
                isMine = false;
            }
            if ( i == 6 || i == 13 )
            {
                isMancala = true;
            }
            else
            {
                isMancala = false;
            }

            Pocket tempPocket = new Pocket(marbleArray[i],isMancala,isMine);
            if(i ==0)
            {
                listPockets.Add(tempPocket);
            }
            else if(i == 13)
            {
                listPockets[i-1].next=tempPocket;
                tempPocket.next = listPockets[0];
                listPockets.Add(tempPocket);
            }
            else
            {
                listPockets[i-1].next=tempPocket;
                listPockets.Add(tempPocket);
            }  
        }

        int startingPocket = 0;
        int distanceAway = 12;
        while (startingPocket < 6)
        {
            listPockets[startingPocket].across = listPockets[startingPocket + distanceAway];
            listPockets[startingPocket+ distanceAway].across = listPockets[startingPocket];
            distanceAway -= 2;
            startingPocket += 1;

        }

    }


    

}


