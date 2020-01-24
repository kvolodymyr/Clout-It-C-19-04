var role = prompt("Enter ur role", "Гость");
var message;
role == 'Гость'?message = 'Привет':role == 'Директор'? message = 'Здравствуйте': role == ''?message = 'Познакомимся?':message = '';
    alert(message);