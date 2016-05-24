"use strict";

app.controller("signupController", [
  "$scope", "$location", "$timeout", "authService", function($scope, $location, $timeout, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
      userName: "",
      passworrd: "",
      confirmPassword: ""
    };

    $scope.signUp = function() {
      authService.saveRegistration($scope.registration).then(function(response) {

          $scope.savedSuccessfully = true;
          $scope.message = "Użytkownik został zarejestrowany poprawnie. Powrót do strony za 2 sekundy.";
          startTimer();
        },
        function(response) {
          var errors = [];
          for (var key in response.data.modelState) {
            for (var i = 0; i < response.data.modelState[key].length; i++) {
              errors.push(response.data.modelState[key][i]);
            }
          }
          $scope.message = "Nieudana próba rejestracji użytkownika: " + errors.join(' ');
        });
    };

    var startTimer = function() {
      var timer = $timeout(function() {
        $timeout.cancel(timer);
        $location.path("/login");
      }, 2000);
    };
  }
]);