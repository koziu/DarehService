
var app = angular.module('DarehServiceApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function($routeProvider) {

  $routeProvider.when("/home", {
    controller: "homeController",
    templateUrl: "/app/Views/home.html"
  });

  $routeProvider.when("/login", {
    controller: "loginController",
    templateUrl: "/app/Views/login.html"
  });

  $routeProvider.when("/signup", {
    controller: "signupController",
    templateUrl: "/app/Views/signup.html"
  });

  $routeProvider.when("/clients", {
    controller: "clientsController",
    templateUrl: "/app/Views/client.html"
  });

  $routeProvider.otherwise({ redirectTo: "/home" });
});

app.config(function($httpProvider) {
  $httpProvider.interceptors.push("authInterceptorService");
});

app.run([
  "authService", function(authService) {
    authService.fillAuthData();
  }
]);