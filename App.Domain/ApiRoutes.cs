namespace App.Domain;

public static class ApiRoutes
{
    private const string Base = "/api";

    public static class TodoRoutes
    {
        private const string ControllerBase = Base + "/todo";
        public const string GetRoute = ControllerBase + "/{id:guid}";
        public const string GetAllRoute = ControllerBase;
        public const string CreateRoute = ControllerBase;
        public const string UpdateRoute = ControllerBase + "/{id:guid}";
        public const string DeleteRoute = ControllerBase + "/{id:guid}";
    }
}