'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:RegistrationService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */


angular.module('configuratorApp').
factory('ProfilService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Account/Profil', {}, {
        'update': { method:'Put',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'loadit': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
    });
});

