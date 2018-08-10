using System;
using System.ComponentModel;

namespace ListViews.ModelView
{
    public class BaseModel: INotifyPropertyChanged
    {
        public BaseModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
