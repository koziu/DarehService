"use strict";
app.factory("clientsService", ["$http", function($http) {

  var serviceBase = "http://localhost:53988/";
  var clientsServiceFactory = {};

  var _getClients = function() {

    return $http.get(serviceBase + "api/Client").then(function(results) {
      return results;
    });
  };

  clientsServiceFactory.getClients = _getClients;

  return clientsServiceFactory;
}])