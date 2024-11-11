namespace Domain.Validators;

public static class ValidationMessage
{
   /// <summary>
   /// Проверить работает ли функция
   /// </summary>
   public static string NotNull = "{PropertyName} не может быть NULL";
   public static string NotEmpty = "{PropertyName} не может быть EMPTY";
   public static string WrongLength = "{PropertyName} должен быть от {min} до {max символов";
   public static string InvalidCharacters = "{PropertyName} не должно содержать специальные символы";
   public static string PositiveNumber = "{PropertyName} должно быть положительным числом";
   public static string NotCorrect = "{PropertyName} неправильное написание";
}