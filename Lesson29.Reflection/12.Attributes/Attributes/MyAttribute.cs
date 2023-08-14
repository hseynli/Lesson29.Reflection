using System;

// Attributlar. 
// Atributlar tip, klasın üzvləri, interfeysin üzvləri və enumların qarşısında təyin olunur.
// Atributların növləri: İstifadə və əvvəlcədən təyin edilmiş.
// [ ....... ] - atributun seksiyası.
// Atributu təyin etmək atrubutun adından və qəbul etdiyi paramterlərdən ibarətdir.

namespace AttributeWork
{
    // Atribut yaratmaq üçün yaradılan klas System.Attribute klasınıdan törəməlidir.
    // Atribut - [AttributeUsage] - istifadə tərəfindən yaradılan atributlara müəyyən xassələr verir.
    // Pozisiyaslı parameter - AttributeTargets, hansı yerdə atributun istifadə ediləcəyini müəyyən edir.
    // Parameter - AttributeTargets.All - atributu ixtiyari element üçün istifadə etməyə imkan verir.
    // Adlı parameter - AllowMultiple = false, bir element üçün atributu neçə dəyə istifadə etməni təyin edir.

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    class MyAttribute : System.Attribute
    {
        private readonly string date;
        public string Date
        {
            get { return date; }
        }

        // Poziyaslı parameterlər konstruktorda formal rol oynayır (yəni, onları istifadə etmək məcburi deyil).
        public MyAttribute(string date)
        {
            this.date = date;
        }

        // Adlı parametrlər public statik olmayan field və ya propery ilə təyin edilir.
        public int Number { get; set; }
    }
}