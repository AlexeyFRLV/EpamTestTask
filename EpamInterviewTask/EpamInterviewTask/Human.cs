using System;

namespace EpamInterviewTask
{
    class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Имя: {FirstName}\tФамилия: {LastName}\tДата рождения: {BirthDate.ToShortDateString()}";
        }
    }
}
