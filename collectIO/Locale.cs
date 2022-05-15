using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using collectIO.Models;

namespace collectIO
{
    public static class Locale
    {
        public static Dictionary<string, string> RU = new Dictionary<string, string>()
        {
            {"Home","Главная"},
            {"Collections","Коллекции"},
            {"Collection items","Айтемы коллекции"},
            {"Profile","Мой кабинет"},
            {"Hello","Привет"},
            {"Logout","Выйти"},
            {"Register","Регистрация"},
            {"Login","Войти"},
            {"Name","Имя"},
            {"Collection Type","Тип коллекции"},
            {"Created","Создано"},
            {"Create","Создать"},
            {"Description","Описание"},
            {"Details","Подробности"},
            {"Items Count","Кол-во айтемов"},
            {"Actions","Действия"},
            {"View","Просмотр"},
            {"Edit","Редактировать"},
            {"Delete","Удалить"},
            {"Add item","Добавить айтем"},
            {"NO","Нет"},
            {"YES","Да"},
            {"Apply","Применить"},
            {"Confirm delete","Удалить?"},
            {"Create new collection","Создать коллекцию"},
            {"My Collections:","Мои коллекции:"},
            {"LIGHT","Светлая"},
            {"DARK","Тёмная"},
            {"Theme:","Тема:"},
            {"Language:","Язык:"},
            {"Loading","Загрузка"},
            {"Collections page:","Все коллекции:"},
            {"Personalize:","Персонализация:"},
            {"None","Отсутствует"},
            {"Games","Игры"},
            {"Books","Книги"},
            {"Music","Музыка"},
            {"Movies","Фильмы"},
            {"Enter your comment:","Введите комменатрий:"},
            {"Comments","Комментарии"},
            {"SEND","Отправить"},
            {"LIKE","Нравится"},
            {"Optional Items fields for this collection","Опциональные поля айтемов в коллекции"},
            {"CHECKBOX","Чекбоксы"},
            {"STRING","Строки"},
            {"NUMBER","Числа"},
            {"TEXT (MARKDOWN)","Текст с оформлением"},
            {"DATE","Даты"},
            {"Property name","Имя поля"},
            {"Show more","Развернуть"},
            {"Show less","Свернуть"},
            {"Biggest Collections","Наибольшие коллекции"},
            {"Last added items","Последние айтемы"},
            {"Select image (drag and drop supported):","Выберите изображение (или перетащите сюда)"}
            

        };
        public static Dictionary<string, string> EN = new Dictionary<string, string>();

        public static Dictionary<string, string> Translations = Reverse();
        public static Dictionary<string, string> Reverse()
        {
            Dictionary<string, string> reversed = new Dictionary<string, string>();
            foreach (var item in RU)
            {
                reversed.Add(item.Key, item.Key);
            }
            EN = reversed;
            return EN;
        }
        public static Dictionary<string, string> SetLocale(this AppUser user)
        {
            Reverse();
            if (user.Language == true)
            {
                Translations = RU;
            }
            else Translations = EN;
            return Translations;
        }

    }
}
