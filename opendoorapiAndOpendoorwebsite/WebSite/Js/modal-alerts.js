/* PNG icons from: http://www.iconarchive.com/ */

var alerts = {
    v: {
        timing: 500,
        background: "alerts-background",
        dialog: "alerts-dialog",
        close: "alerts-close",
        p: {
            icon: "http://icons.iconarchive.com/icons/custom-icon-design/flatastic-8/128/Maintenance-icon.png",
            title: "Error",
            message: "Some error occured",
            css: ""
        }
    },
    build: {
        run: function() {
            var interval = setInterval( function() {
                if ( typeof jQuery !== undefined ) {
                    alerts.build.dialog();
                    clearInterval( interval );
                }
            }, 100 );
        },
        dialog: function() {
            if ( jQuery( "." + alerts.v.dialog ).size() == 0 ) {
                jQuery( "body" ).append(
                    '<div class="' + alerts.v.dialog + '">' +
                        '<div><img class="icon" src="' + alerts.v.p.icon + '"><span>' + alerts.v.p.title + '</span></div>' +
                        '<p>' + alerts.v.p.message + '</p>' +
                        '<div><a class="' + alerts.v.close + '">Close</a></div>' +
                    '</div>'
                );
                jQuery( "." + alerts.v.close ).unbind( "click" ).bind( "click", function( e ) {
                    e.preventDefault();
                    alerts.hide();
                });
                jQuery( window ).resize( function() {
                    alerts.build.align();
                });
            }
            if ( jQuery( "." + alerts.v.background ).size() == 0 ) {
                jQuery( "body" ).append(
                    '<div class="' + alerts.v.background + '"></div>'
                );
            }
        },
        prepare: function( p ) {
            var dialog = jQuery( "." + alerts.v.dialog );
            for ( var key in p ) {
                if ( p.hasOwnProperty( key ) ) {
                    alerts.v.p[ key ] = ( p[ key ] ) ? p[ key ] : alerts.v.p[ key ];
                }
            }
            jQuery( "> div:first-child img", dialog ).attr({ src: alerts.v.p.icon });
            jQuery( "> div:first-child span", dialog ).html( alerts.v.p.title );
            jQuery( "> p", dialog ).html( alerts.v.p.message );
            jQuery( dialog ).addClass( alerts.v.p.css );
            alerts.build.align();
        },
        align: function() {
            var dialog = jQuery( "." + alerts.v.dialog );
            dialog.css({
                "top": parseInt( jQuery( window ).height() / 2 ) - parseInt( dialog.outerHeight( true ) / 2 ),
                "left": parseInt( jQuery( window ).width() / 2 ) - parseInt( dialog.outerWidth( true ) / 2 )
            });
        }
    },
    show: function( p ) {
        if ( p ) {
            alerts.build.prepare( p );
        }
        jQuery( "." + alerts.v.background ).addClass( "alerts-show" );
        var dialog = jQuery( "." + alerts.v.dialog );
        dialog.removeClass( "alerts-show-end" );
        setTimeout( function() {
            dialog.addClass( "alerts-show" );
        }, alerts.v.timing );
    },
    hide: function() {
        var dialog = jQuery( "." + alerts.v.dialog );
        jQuery( "." + alerts.v.dialog ).addClass( "alerts-show-end" ).removeClass( "alerts-show" ).removeClass( alerts.v.p.css );
        setTimeout( function() {
            jQuery( "." + alerts.v.background ).removeClass( "alerts-show" );
        }, alerts.v.timing );
    }
};

alerts.build.run();