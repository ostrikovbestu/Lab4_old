using System;

namespace Lr4
{
    public static class MathOperation
    {
        // поиск максимального
        public static int Max(List list)
        {
            // назначаем в качестве промежуточного максимума первый элемент из списка
            var max = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                // если текущий максимум меньше чем элемент
                if (max < list[i])
                {
                    // то обновляем значение текущего максимума
                    max = list[i];
                }
            }
            
            return max;
        }

        // поиск минимального
        public static int Min(List list)
        {
            // назначаем в качестве промежуточного минимума первый элемент из списка
            var min = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                // если текущий минимум больше чем элемент
                if (min > list[i])
                {
                    // то обновляем значение текущего минимума
                    min = list[i];
                }
            }

            return min;
        }

        public static int Count(List list)
        {
            return list.Length;
        }

        // метод расширения: подсчет количества слов с заглавной буквы 

        public static int CountCapitalWords(this string str)
        {
            // разбиваем строку на слова по символам разделителям
            var words =
                str
                  .Split(new[] { ' ', '.', '!', '?', '\n', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            // количество слов начинающихся с заглавной буквы
            var count = 0;
            // перебираем все слова в цикле
            foreach (var word in words)
            {
                // убираем пробельные символы
                // с обоих концов строки
                var trimmed = word.Trim();
                // если строка пустая
                if (string.IsNullOrWhiteSpace(trimmed))
                {
                    // то переходим к следующему элементу
                    // в цикле если он есть
                    continue;
                }

                // получаем первый символ
                var ch = trimmed[0];
                // проверяем что он является буквой и заглавный
                if (char.IsLetter(ch) && char.IsUpper(ch))
                {
                    // увеличиваем счетчик
                    count++;
                }
            }

            // возвращаем результат
            return count;
        }

        // Метод расширения: Проверка на повторяющиеся элементы в списке
        public static bool HasDuplicates(this List list)
        {
            // если в списке всего 1 элемент
            if (list.Length <= 1)
            {
                // то там точно нет повторений
                return false;
            }
            // двойной цикл
            // берем элемент
            for (int i = 0; i < list.Length; i++)
            {
                // и проводим сравнения со всеми последующими в списке
                for (int j = i + 1; j < list.Length; j++)
                {
                    // если элементы равны
                    if (list[i] == list[j])
                    {
                        // значит повторения есть
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}