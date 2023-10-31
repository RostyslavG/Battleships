using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Battleships.ViewModels
{
    public class BattleshipsVM : INotifyPropertyChanged
    {
        int[][] demoMap;
        Random random = new Random();
        string time1 = "";
        DateTime time;
        public CellVM[][] OurField { get; private set; }
        public CellVM[][] CompField { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Time
        {
            get => time1;
            set
            {
                time1 = value;
                OnPropertyChanged();
            }
        }
        public BattleshipsVM()
        {
            demoMap = GenerateMap();
            OurField = IniFields(demoMap);
            demoMap = GenerateMap();
            CompField = IniFields(demoMap);
            ShowTime();
        }
        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ShowTime();
                });
            }
        }

        public void ShowTime()
        {
            time = DateTime.Now;
            Time = time.ToShortTimeString();
        }

        public CellVM[][] IniFields(int[][] str)
        {
            CellVM[][] map = new CellVM[10][];
            for (int i = 0; i < 10; i++)
            {
                map[i] = new CellVM[10];
                for (int j = 0; j < 10; j++)
                    map[i][j] = new CellVM(str[i][j]);
            }
            return map;
        }

        public void ShootToAs(int x, int y)
        {
            OurField[y][x].Shoot();
        }

        public int[][] GenerateMap()
        {
            demoMap = new int[10][];
            for (int i = 0; i < 10; i++)
                demoMap[i] = new int[10];

            PlaceShips(1, 4); // 1 палубний - 4 
            PlaceShips(2, 3); // 2 палубних - 3 
            PlaceShips(3, 2); // 3 палубних - 2 
            PlaceShips(4, 1); // 4 палубних - 1 

            return demoMap;
        }

        public void PlaceShips(int shipSize, int shipCount)
        {
            for (int i = 0; i < shipCount; i++)
            {
                bool placed = false;
                while (!placed)
                {
                    int row = random.Next(0, 10);
                    int col = random.Next(0, 10);
                    bool horizontal = random.Next(2) == 0;

                    if (CanPlaceShip(row, col, horizontal, shipSize))
                    {
                        PlaceShip(row, col, horizontal, shipSize);
                        placed = true;
                    }
                }
            }
        }

        public bool CanPlaceShip(int row, int col, bool horizontal, int size)
        {
            if (horizontal)
            {
                if (col + size > 10)
                    return false;

                for (int c = col; c < col + size; c++)
                {
                    if (demoMap[row][c] != 0)
                        return false;
                }
            }
            else
            {
                if (row + size > 10)
                    return false;

                for (int r = row; r < row + size; r++)
                {
                    if (demoMap[r][col] != 0)
                        return false;
                }
            }

            // перевірка на перетин з іншими кораблями
            int vidstup = 1;
            if (horizontal)
            {
                for (int r = Math.Max(0, row - vidstup); r < Math.Min(row + 1 + vidstup, 10); r++)
                {
                    for (int c = Math.Max(0, col - vidstup); c < Math.Min(col + size + vidstup, 10); c++)
                    {
                        if (demoMap[r][c] != 0)
                            return false;
                    }
                }
            }
            else
            {
                for (int r = Math.Max(0, row - vidstup); r < Math.Min(row + size + vidstup, 10); r++)
                {
                    for (int c = Math.Max(0, col - vidstup); c < Math.Min(col + 1 + vidstup, 10); c++)
                    {
                        if (demoMap[r][c] != 0)
                            return false;
                    }
                }
            }
            return true;
        }

        public void PlaceShip(int row, int col, bool horizontal, int size)
        {
            if (horizontal)
            {
                for (int c = col; c < col + size; c++)
                    demoMap[row][c] = 1;
            }
            else
            {
                for (int r = row; r < row + size; r++)
                    demoMap[r][col] = 1;
            }
        }
    }
}
