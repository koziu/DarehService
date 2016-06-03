﻿
var app = angular.module("DarehServiceApp", ["ngRoute", "LocalStorageModule", "angular-loading-bar"]);

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
  $routeProvider.when("/refresh", {
    controller: "refreshController",
    templateUrl: "/app/views/refresh.html"
  });

  $routeProvider.when("/tokens", {
    controller: "tokensManagerController",
    templateUrl: "/app/views/tokens.html"
  });

  $routeProvider.when("/associate", {
    controller: "associateController",
    templateUrl: "/app/views/associate.html"
  });

  $routeProvider.otherwise({ redirectTo: "/home" });
});

var serviceBase = "http://localhost:53988/";

app.constant("ngAuthSettings", {
  apiServiceBaseUri: serviceBase,
  clientId: "ngAuthApp"
});

app.config(function($httpProvider) {
  $httpProvider.interceptors.push("authInterceptorService");
});

app.run([
  "authService", function(authService) {
    authService.fillAuthData();
  }
]);