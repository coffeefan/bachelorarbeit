'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:RegistrationService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */


angular.module('configuratorApp').
factory('ProjectService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Projects', {id:'@id'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'findAll': { method:'Get',isArray:true, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'add': { method:'Post',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'update': { method:'Put',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });



});

