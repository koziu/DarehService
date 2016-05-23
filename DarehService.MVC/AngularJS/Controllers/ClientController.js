(function() {

  var darehServiceApp = angular.module('DarehApp', []);
 
  darehServiceApp.service("clientService", function($http, $q) {
    var deferred = $q.defer();
    $http.get('http://localhost:53988/api/Client/?callback=JSON_CALLBACK').success(function (data) {
      deferred.resolve(data);
    }).error(function(data, status, headers, config) {
      console.log(data);
    });

    this.getClients = function() {
      return deferred.promise;
    }

  }).controller("ClientListController", function($scope, clientService) {

    var promise = clientService.getClients();
    promise.then(function(data) {
      $scope.clients = data;
      console.log(data);
    });
  });

})();


