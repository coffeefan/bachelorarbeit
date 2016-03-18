'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ForgotPasswordCtrl
 * @description
 * # ForgotPasswordCtrl
 * Controller where the User send a E-Mail for reseting his Password
 */
angular.module('configuratorApp')
    .controller('ForgotPasswordCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location)  {
        $rootScope.pagetitle="Passwort vergessen";

    });