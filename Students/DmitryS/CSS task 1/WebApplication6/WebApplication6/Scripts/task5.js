var flag = false;
var N1;
var N2;
var answer;
for (; flag == false;) {
    N1 = Math.floor(Math.random() * 11) + 10;
    N2 = Math.floor(Math.random() * 11) + 10;
    answer = Number(prompt(N1 + "+" + N2 + "=", ""));
    answer == N1 + N2 ? flag = true : flag = false;
}
