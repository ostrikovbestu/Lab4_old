using System;

namespace Lr4
{
    public class List
    {
        // массив для хранения элементов
        private int[] data;
        // конструктор без параметров
        // "пустой" список
        public List():this(0)
        {
        }

        // конструктор "копирования"
        public List(List list):this(list.Length)
        {
            Array.Copy(list.data, data, list.Length);
        }

        // конструктор для инициализации
        // указанного количества элементов
        public List(int count)
        {
            data = new int[count];
            // создание объекта для учета
            // даты и времени сохранения
            DateOfCreation = new Date();
            // объект вложенного класса для
            // учета имени, организации и ID
            Owner = new OwnerInfo("Name", "Org");
        }

        // вложенный класс Owner
        public class OwnerInfo
        {
            // статическое поле для хранения id
            private static int id;

            public int Id { get; }

            public string Name { get; }

            public string Org { get; }

            public OwnerInfo(string name, string org)
            {
                Id = id++;
                Name = name;
                Org = org;
            }

            public override string ToString()
            {
                return $"{Id}. {Name, 10} {Org}";
            }
        }

        public OwnerInfo Owner { get; }

        public class Date
        {
            public DateTime DateTime { get; }

            public Date()
            {
                DateTime = DateTime.Now;
            }

            public override string ToString()
            {
                return DateTime.ToString();
            }
        }

        public Date DateOfCreation { get; }

        // индексатор
        public int this[int i]
        {
            get => data[i];
            // сеттер только для чтения чтобы
            // значения в списке нельзя было изменять извне
            private set => data[i] = value;
        }

        // количество элементов в списке
        public int Length => data.Length;

        // метод для удаления первого элемента
        public void RemoveFirst()
        {
            // если есть хоть 1 элемент
            if (data.Length > 0)
            {
                // то переносим все элементы "влево"
                // тем самым затирая значение первого
                for (int i = 0; i < data.Length - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                // затем сокращаем массив
                Array.Resize(ref data, data.Length - 1);
            }
        }

        // метод для удаления последнего элемента
        public void RemoveLast()
        {
            // если есть хоть 1 элемент
            if (data.Length > 0)
            {
                // изменяем размер массива
                // тем самым сокращая список
                Array.Resize(ref data, data.Length - 1);
            }
        }

        // метод для вставки элемента в начало
        public void AddFirst(int value)
        {
            // запоминаем текущую длину списка
            var lng = data.Length;
            // расширяем его на 1
            Array.Resize(ref data, data.Length + 1);
            // передвигаем каждый элемент "вправо"
            for (int i = lng; i > 0; i--)
            {
                data[i] = data[i - 1];
            }
            // первым записываем переданное значение
            data[0] = value;
        }

        public void AddLast(int value)
        {
            // запоминаем текущую длину списка
            var lng = data.Length;
            // расширяем массив
            Array.Resize(ref data, data.Length + 1);
            // записываем переданное значение
            data[lng] = value;
        }

        // метод для добавления нового списка
        public void AppendList(List list)
        {
            if (list is null)
            {
                return;
            }
            // запоминаем текущую длину списка
            var lng = data.Length;
            // расширяем массив, добавляя столько элементов сколько находится
            // в списке list
            Array.Resize(ref data, lng + list.data.Length);
            // копируем значения из списка list в список
            Array.Copy(list.data, 0, data, lng, list.data.Length);
        }

        // оператор ==
        public static bool operator ==(List a, List b)
        {
            // если оба значения - null значит равны
            if (a is null && b is null)
            {
                return true;
            }

            // если один null а второй - нет значит не равны
            if ((a is null && !(b is null))
              || (!(a is null) && b is null))
            {
                return false;
            }
            // если длины списков отличаются
            // значит не равны
            if (a.Length != b.Length)
            {
                return false;
            }
            // проверяем попарно на равенство
            for (int i = 0; i < a.Length; i++)
            {
                // как только нашли отличающиеся элементы
                if (a[i] != b[i])
                {
                    // значит списки не равны
                    return false;
                }
            }
            // все элементы совпадают
            return true;
        }

        public static bool operator !=(List a, List b)
        {
            return !(a == b);
        }

        // оператор добавления значения в начало
        public static List operator +(List a, int value)
        {
            if (a is null)
            {
                return null;
            }

            // создаем копию
            var res = new List(a);
            // добавляем значение
            res.AddFirst(value);
            // возвращаем результат
            return res;
        }

        // оператор уножения - добавление одного списка к другому
        public static List operator *(List a, List b)
        {
            if (a is null)
            {
                return null;
            }

            // создаем копию
            var res = new List(a);
            // вызываем метод
            res.AppendList(b);
            // возвращаем результат
            return res;
        }

        // оператор декримента - удаление элемента из списка
        public static List operator --(List list)
        {
            if (list is null)
            {
                return list;
            }

            var res = new List(list);
            res.RemoveFirst();
            return res;
        }

        public override string ToString()
        {
            // выводим все значения через "," в конце в скобочках отображается число элементов
            return $"[{string.Join(", ", data)}]({Length})";
        }

        // переопределение метода Equals
        public override bool Equals(object obj)
        {
            return obj is List list && this == list;
        }

        // переопределение получения хеша
        public override int GetHashCode()
        {
            return HashCode.Combine(data, Length);
        }
    }
}