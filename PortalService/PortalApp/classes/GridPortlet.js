

Ext.define('Ext.app.GridPortlet', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.gridportlet',
    uses: [
        'Ext.data.ArrayStore'
    ],
    height: 300,
    change: function (val) {
        if (val > 0) {
            return '<span style="color:green;">' + val + '</span>';
        } else if (val < 0) {
            return '<span style="color:red;">' + val + '</span>';
        }
        return val;
    },

    /**
     * Custom function used for column renderer
     * @param {Object} val
     */
    pctChange: function (val) {
        if (val > 0) {
            return '<span style="color:green;">' + val + '%</span>';
        } else if (val < 0) {
            return '<span style="color:red;">' + val + '%</span>';
        }
        return val;
    },

    initComponent: function () {

        var store = Ext.create('Ext.data.ArrayStore', {
            fields: [
               { name: 'company' },
               { name: 'change', type: 'float' },
               { name: 'pctChange', type: 'float' }
            ],
            autoLoad: true,
            proxy: {
                type: 'ajax',
                api: {
                    read: 'http://localhost:56392/Portal.svc/GetData'
                },
                reader: {
                    type: 'json',
                }
            }
        });

        Ext.apply(this, {
            //height: 300,
            height: this.height,
            store: store,
            stripeRows: true,
            columnLines: true,
            columns: [{
                id: 'company',
                text: 'Company',
                //width: 120,
                flex: 1,
                sortable: true,
                dataIndex: 'company'
            }, {
                text: 'Change',
                width: 75,
                sortable: true,
                renderer: this.change,
                dataIndex: 'change'
            }, {
                text: '% Change',
                width: 75,
                sortable: true,
                renderer: this.pctChange,
                dataIndex: 'pctChange'
            }]
        });

        this.callParent(arguments);
    }
});
