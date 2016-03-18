'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the configuratorApp
 */
angular.module('configuratorApp')
  .controller('MainCtrl', function ($rootScope) {
      $rootScope.pageTitle="Main";
    this.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
