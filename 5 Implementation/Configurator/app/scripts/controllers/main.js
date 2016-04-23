'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the configuratorApp
 */
angular.module('configuratorApp')
  .controller('MainCtrl', function ($rootScope,$location) {
      $rootScope.pageTitle="Welcome";
      $scope.openRegister=function(){
          $location.load("/registration");
      }
  });
