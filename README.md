Необходимо установить Extended WPF Toolkit для проекта AlienLanguageGui, команда:

Install-Package Extended.Wpf.Toolkit

ЗАДАЧА "ЯЗЫК ЧУЖИХ"

Британские ученые наняли Вас для того, чтобы Вы написали им транслятор с языка чужих, который умеет определять число, получив на вход строку S и длину N конечной строки R. Транслятор должен работать по следующему интерфейсу:
```
interface IAlienTranslator
{
long Translate(string s, long n);
}
```
Кроме того, ученые хотят, чтобы вы покрыли свой транслятор тестами, особенно для больших чисел N.

Ограничения:

1) 1 <= |s| <= 100;

2) 1 <= n <= 10^12;

Пример 1:

Вызов метода: Translate(“zxz”, 10)

Выходные данные: 7

Объяснение:

После обработки ГА получилась строка R длиной 10 букв: zxzzxzzxzz. Эта строка содержит 7 букв «z».

Пример 2:

Вызов метода: Translate(“z”, 1000000000000)

Выходные данные: 1000000000000

Объяснение:

После обработки ГА получилась строка R, состоящая из триллиона (10^12) букв «z», поэтому вывод равен 1000000000000.

ЗАДАЧА "МИГРАЦИЯ УТОК"

Задача: 

На озере живут странные утки, которые каждый год мигрируют на другое озеро. Некоторые озера соединены дорогами, но утки боятся передвигаться по дорогам, поэтому пользуются тропами. 

Вожак уток установил, что тропой соединены каждые два озера, тогда и только тогда, когда эти озера не соединены дорогой. Помогите Вожаку определить количество троп, которое предстоит пересечь уткам, чтобы добраться от текущего озера до каждого другого озера.

Вводные данные:

1) Первая строка содержит количество озер N и количество дорог M между озерами, разделенные пробелом.

2) Каждая следующая из M строк содержит два номера, разделенные пробелом, тех озер, которые соединены дорогой (все номера озер начинаются с 1).

3) Последняя строка содержит номер озера, на котором обитают утки в данный момент.

Выводные данные:

Выводятся N-1 чисел, которые соответствуют количеству троп, соединяющих текущее озеро с каждым из других озер, отсортированных по порядковому номеру.

Пример:

Ввод:

4 2

1 2

1 3

1

Вывод:

2 2 1
