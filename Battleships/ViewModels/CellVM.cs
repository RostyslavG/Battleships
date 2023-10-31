using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Battleships.ViewModels
{
    public class CellVM : INotifyPropertyChanged
    {
        public bool isShip, isHit;
        Visibility vis = Visibility.Collapsed;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public Visibility Miss { 
            get => vis;
            set
            {
                isHit = false;
                vis = value;
                OnPropertyChanged();
            }
        }

        public Visibility Hit
        {
            get => vis;
            set
            {
                isHit = true; 
                vis = value;
                OnPropertyChanged();
            }
        }


        public CellVM() 
        {
            Miss = Visibility.Collapsed;
        }

        public CellVM(int s = 0)
        {
            isShip = s == 1;
            isHit = true;
        }

        public void Shoot()
        {
            if (isShip)
            {
                Hit = Visibility.Visible;
                isHit = true;
            }
            else
            {
                Miss = Visibility.Visible;
                isHit = false;
            }
        }

        public void IsShip()
        {
            isShip= true;
        }

        //public ICommand Shoot
        //{ 
        //    get
        //    {
        //        return new RelayCommand(() =>
        //        {
        //            Shoot();
        //        });
        //    }
        //}
    }
}
