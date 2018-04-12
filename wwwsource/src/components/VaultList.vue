<template>
    <div class="manage-vaults">
      <dashboard></dashboard>
      <div class="container">
        <div class="flexor mar-bt">
          <h2>Manage Vaults</h2>
          <div @click="toggleShow()" class="blue-icon pointer">
            <span>New Vault</span>
            <i class="fa fa-plus"></i>
          </div>
        </div>
  
        <div v-if="show == true">
          <form class="flexor" @submit.prevent="createVault()">
            <div class="form-group pad-r">
              <input v-model="newVault.name" type="text" class="form-control" placeholder="Vault Name">
            </div>
            <div class="form-group long pad-r">
              <input v-model="newVault.description" type="text" class="form-control" placeholder="Vault Description">
            </div>
            <div class="form-group">
              <button type="submit" class="btn dkblue">Add Vault</button>
            </div>
          </form>
        </div>
  
        <div class="list-group">
          <div class="list-group-item" v-for="vault in vaults">
            <vault :vault="vault"></vault>
          </div>
        </div>
  
      </div>
    </div>
  </template>
<script>
    //import Keep from './Keep.vue'
    import Dashboard from './Dashboard'
    export default {
        name: 'VaultList',
        components: {
            Dashboard,
            Keep
        },
        data() {
            return {
                show: false,
                newVault: {}
            }
        },
        props: [
            vault
        ],
        mounted() {
            this.$store.dispatch('getVaults');
        },
        computed: {
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {
            createVault() {
                this.$store.dispatch('createVault', this.newVault)
                this.show = false;
            },
            deleteVault() {
                this.$store.dispatch('deleteVault', vault)
            },
            toggleShow() {
                if (this.show == false) {
                    this.show = true
                } else {
                    this.show = false
                }
            }
        }
    }
</script>
<style scoped>
    .grid-header {
        font-weight: bold;
        border-bottom: solid 2px rgb(60, 81, 121);
    }
    
    .grid-content {
        font-size: 12pt;
    }
    
    .draw-border {
        border-bottom: solid 2px rgb(60, 81, 121);
    }
    
    .updated-contact.form-control {
        width: 90%
    }
    
    .mar-bt {
        margin-bottom: 1rem;
    }
    
    .dkblue {
        background-color: rgb(60, 81, 121);
        color: white;
        font-size: 1rem;
        transition: all .3s linear;
    }
    
    .dkblue:hover {
        background-color: rgb(166, 197, 255);
    }
    
    .pad-r {
        padding-right: .5rem;
    }
    
    .long {
        flex-grow: 2;
    }
    
    .flexor {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    
    .pointer {
        cursor: pointer;
    }
    
    .grey-icon {
        color: rgb(96, 131, 195);
        transition: all .2s linear;
        font-size: 1rem;
    }
    
    .grey-icon:hover {
        color: rgb(60, 81, 121);
    }
</style>