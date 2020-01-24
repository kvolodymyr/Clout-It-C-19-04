var i;
var F1 = 1;
var F2 = 1;
var tmp;
console.log(F1);
console.log(F2)
for (i = 2; i < 15; i++)
{
    tmp = F2;
    F2 = F1 + F2;
    F1 = tmp;
    console.log(F2)
}