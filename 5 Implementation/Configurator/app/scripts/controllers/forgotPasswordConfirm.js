'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ForgotPasswordConfirmCtrl
 * @description
 * # ForgotPasswordConfirmCtrl
 * Controller where the User reset his Password after getting an E-Mail
 */
angular.module('configuratorApp')
    .controller('ForgotPasswordConfirmCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location)  {
        $rootScope.pagetitle="Passwort vergessen";

    });