Ext.define('Ext.app.GridPortlet', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.gridportlet',
    uses: [
        'Ext.data.Store'
    ],
    plugins: [Ext.create('Ext.grid.plugin.RowEditing', {
        clicksToMoveEditor: 1
        , autoCancel: false
    })],
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
        Ext.define('test.Company', {
            extend: 'Ext.data.Model',
            fields: ['company', { name: 'change', type: 'float' },
               { name: 'pctChange', type: 'float' }],
            ipProperty: 'company'
        });
        var store = Ext.create('Ext.data.Store', {
            model: 'test.Company',
            autoLoad: true,
            pageSize:1,
            proxy: {
                type: 'ajax',
                api: {
                    read: '/Portal.svc/GetData',
                    create: '/Portal.svc/Company',
                    update: '/Portal.svc/UpdateCompany',
                    destroy: '/Portal.svc/DeleteCompany'
                },
                reader: {
                    type: 'json',
                    root: 'GridPortletResult',
                    totlaProperty: 'total'
                }
            }
        });
        var searchTextField = Ext.create('Ext.form.field.Text', {
            fieldLabel:'Company Search',
            enableKeyEvents: true,
            listeners: {
                keyup: {
                    fn: function (field, e) {
                        var val = field.getValue();

                        store.filterBy(function (recode) {
                            return recode.get('company').substring(0, val.length) === val;
                        },this);
                    }
                },
                buffer:250
            }
        })
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
                , editor: {
                    xtype: 'textfield'
                }
            }, {
                text: 'Change',
                width: 75,
                sortable: true,
                renderer: this.change,
                dataIndex: 'change'
                , editor: {
                    xtype: 'textfield'
                }
            }, {
                text: '% Change',
                width: 75,
                sortable: true,
                renderer: this.pctChange,
                dataIndex: 'pctChange'
                , editor: {
                    xtype: 'textfield'
                }
            }],
            tbar: [{
                xtype: 'button'
                , text: 'Add'
                , handler: function (btn) {
                    var text = Ext.create('test.Company', {
                        company: '',
                        change: 0,
                        pctChange: 0,
                    });
                    btn.up("grid").getStore().insert(0, text);
                    btn.up("grid").plugins[0].startEdit(0, 0);
                }
                , scope: this
            }, {
                xtype: 'button'
                , text: 'Delete'
                , handler: function (btn) {
                    btn.up("grid").getStore().remove(btn.up("grid").getSelectionModel().getSelection());
                }
                , scope: this
            },
            {
                xtype: 'button'
                        , text: 'Save'
                       , handler: function (btn) {
                           btn.up("grid").getStore().sync({
                               success: function (response) {
                                   btn.up("grid").getStore().loadData();
                                   btn.up("grid").getStore().load();
                               }
                           });
                       }
                       , scope: this
            }],
                    
            bbar: Ext.create('Ext.PagingToolbar', {
               store: store,
                displayInfo: true,
                displayMsg: '{0} - {1} of {2}',
                emptyMsg: "No topics to display"
            })
        });
        //this.bbar.add(searchTextField);
        //store.loadPage(1);
        this.callParent(arguments);
    }
});
