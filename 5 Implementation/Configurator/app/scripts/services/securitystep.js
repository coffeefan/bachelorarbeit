'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:RegistrationService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */


angular.module('configuratorApp').
factory('ProjectSecurityService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/SecurityStepProject/', {id:'@id'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'add': { method:'Post',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'update': { method:'Put',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'remove': { method:'delete',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });



});

angular.module('configuratorApp').
factory('AvailableSecurityService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/SecurityStepAvailable/', {id:'@id'}, {
        'findAll': { method:'Get',isArray:true, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'add': { method:'Post',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'update': { method:'Put',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'remove': { method:'delete',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});

angular.module('configuratorApp').
factory('SecurityStepProjectListService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/SecurityStepProjectList/', {id:'@id'}, {
        'findAll': { method:'Get',isArray:true, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}},
        'update': { method:'Put',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});

angular.module('configuratorApp').
factory('SecurityStepCompareInfoService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/SecurityStepCompareInfo/', {id:'@id'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});




