Feature: NortWindTests
	Как пользователь системы
	Я хочу совершать входы и выход из системы
	И проводить операции в системе

@mytag
Scenario: Тесты
	Given Я открываю "http://localhost:5000/" url
	When Я вхожу в систему с именем "user" и паролем "user"
	Then Вход успешен

	When Я нажимаю на ссылку All Products 
	Then Открывается страница All Products
	When Я нажимаю на ссылку Create new
	Then Открывается страница Product editing
	And Я создаю новый продукт

	Then Я проверяю созданный продукт

	And Выхожу из систем
