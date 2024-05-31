# Описание проекта
## Регистрация
За регистрацию отвечает контроллер Auth. Для того, чтобы пользовться api, надо зарегистрироваться (путь /registration).
Для получения прав админа нужно ввести роль "admin". После этого будет выдан токен, который надо вставить в окошечко в правом верхнем углу экрана
(В swagger зеленая кнопка Authorize). После этого будут доступны команды для Администратора (контроллер Admin).
В другом случае будут достцпны команды только контроллера User. Если пользователь уже сущетствует, то можно методом /login получить токен и войти как другой пользователь

## User
/get-all

Получить список всех пользователей (в задании такого метода не было, это сделано для того, чтобы лучше отслеживать все изменения)

/get-my-account

Получить информацию о текущем аккаунте

/change-user-info

Поменять некоторую информацию о текущем пользователе (имя, пол, дату рождения)

/change-user-password/{password}

Поменять пароль текущего пользователя

/change-user-login/{login}

Поменять логин текущего пользователя

/get-user-by-login-and-password/{login}/{password}

Получить пользователя по логину и паролю


## Admin
/change-user-info-for-admin

Поменять информацию для пользователя с логином userLogin (имя, пол, дату рождения)

/change-user-password/{userLogin}/{psasword}

Поменять пароль для пользователя с логином userLogin

/change-user-login/{userLogin}/{newLogin}

Поменять логин для пользователя с логином userLogin

/create-user

Создать нового пользователя

/admin/restore-user/{login}

Сделать снова активным пользователя с логином login

/get-all-active-users

Получить список всех активных пользовтелей

/get-user/{login}

Получить пользователя по логину

/get-user-greather-than/{age}
Получить список пользователей старше определенного возраста
/delete-user/{login}
Удалить пользователя с логином login
/delete-user-soft{login}
Сделать неактивным пользователя с логиом login

