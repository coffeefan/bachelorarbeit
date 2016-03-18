'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:LogoutCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can logout himself
 */
angular.module('configuratorApp')
    .controller('LogoutCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location)  {
        $rootScope.pagetitle="Logout";
        if(typeof $sessionStorage.accessToken!= 'undefined') {

            delete $sessionStorage.accessToken;
            location.reload();
        }

    });