namespace Basic.Samples.TestDataBuilder;

public class TestUsers
{
    public static User ARegularUser() => new User("Triniti", "tri", "asdasd", "ROLE_USER");

    public static User AnAdmin() => new User("Agent Smith", "smith", "qweqwe", "ROLE_ADMIN");
}
