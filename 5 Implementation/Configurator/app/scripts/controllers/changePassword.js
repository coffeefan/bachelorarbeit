'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ChangePasswordCtrl
 * @description
 * # ChangePasswordCtrl
 * Controller where the User change his Password
 */
angular.module('configuratorApp')
    .controller('ChangePasswordCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location)  {
        $rootScope.pagetitle="Passwort ändern";

    });