import '@/css/main.css'
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import MISAIconAndTextButton from './components/base/button/MISAIconAndTextButton.vue'
import MISAOnlyIconButton from './components/base/button/MISAOnlyIconButton.vue'
import MISAIStandardButton from './components/base/button/MISAStandardButton.vue'
import MISAInputStandard from './components/base/input/MISAInputStandard.vue'
import MISAInputWithIcon from './components/base/input/MISAInputWithIcon.vue'
import MISAComboBox from './components/base/MISAComboBox.vue'
import MISADialog from './components/base/MISADialog.vue'
import MISANavItem from './components/base/MISANavItem.vue'
import MISATable from './components/base/MISATable.vue'
import MISAenum from './helper/MISAenum'
import MISAresource from './helper/MISAresource'
// import setupInterceptors from './services/setupInterceptors.js';
import { usePropertyStore } from './stores/property'
const app = createApp(App)
app.use(createPinia())
const propertyStore = usePropertyStore()
// setupInterceptors(propertyStore);
app.use(router)
app.config.devtools = true
app.component('MISAOnlyIconButton', MISAOnlyIconButton)
app.component('MISAIStandardButton', MISAIStandardButton)
app.component('MISAInputStandard', MISAInputStandard)
app.component('MISAInputWithIcon', MISAInputWithIcon)
app.component('MISAComboBox', MISAComboBox)
app.component('MISADialog', MISADialog)
app.component('MISANavItem', MISANavItem)
app.component('MISATable', MISATable)
app.component('MISAIconAndTextButton', MISAIconAndTextButton)
app.provide('$MISAresource', MISAresource)
app.provide('$MISAenum', MISAenum)
app.mount('#app')
